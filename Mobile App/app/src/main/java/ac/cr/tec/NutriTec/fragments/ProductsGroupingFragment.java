package ac.cr.tec.NutriTec.fragments;

import android.content.SharedPreferences;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;

import android.preference.PreferenceManager;
import android.util.Log;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.Toast;

import com.google.android.material.button.MaterialButton;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;

import ac.cr.tec.NutriTec.Const.Const;
import ac.cr.tec.NutriTec.R;
import ac.cr.tec.NutriTec.customViews.DeleteButton;
import ac.cr.tec.NutriTec.interfaces.ChoiceSelected;
import ac.cr.tec.NutriTec.network.NetworkCommunicator;
import ac.cr.tec.NutriTec.viewModel.productListViewModel;
import okhttp3.Call;
import okhttp3.Callback;
import okhttp3.Response;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link ProductsGroupingFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class ProductsGroupingFragment extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;
    private String username;
    private ArrayList<String> productsSelected;
    private ArrayList<String> recipesSelected;
    private ArrayList<String> recipesOwner;
    private MaterialButton addProductButton;
    private MaterialButton confirmButton;
    private EditText productInputName;
    private LinearLayout productList;
    private productListViewModel viewModel;
    private ProductsGroupingFragment currentFragment;


    public ProductsGroupingFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment ProductsGroupingFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static ProductsGroupingFragment newInstance(String param1, String param2) {
        ProductsGroupingFragment fragment = new ProductsGroupingFragment();
        Bundle args = new Bundle();
        args.putString(ARG_PARAM1, param1);
        args.putString(ARG_PARAM2, param2);
        fragment.setArguments(args);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            mParam1 = getArguments().getString(ARG_PARAM1);
            mParam2 = getArguments().getString(ARG_PARAM2);
        }

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View currentView=inflater.inflate(R.layout.fragment_product_grouping, container, false);
        currentFragment=this;
        productsSelected=new ArrayList<>();
        recipesSelected=new ArrayList<>();
        recipesOwner=new ArrayList<>();
        getInstances(currentView);
        //setListeners();
        return currentView;
    }
    private void getInstances(View view){
        addProductButton=view.findViewById(R.id.add_product_button);
        confirmButton=view.findViewById(R.id.save_recipe);
        productInputName=view.findViewById(R.id.product_label);
        productList=view.findViewById(R.id.product_list);
        SharedPreferences preferences= PreferenceManager.getDefaultSharedPreferences(getContext());
        username=preferences.getString(Const.user,"");
    }
    private void setListeners(){
        addProductButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                final String productName=productInputName.getText().toString();
                HashMap<String,String> params=new HashMap<>();
                params.put(Const.searchBarsParam,productName);
                NetworkCommunicator.get(Const.searchUrl, params, new Callback() {
                    @Override
                    public void onFailure(@NonNull Call call, @NonNull IOException e) {
                        Toast toast=Toast.makeText(getActivity().getApplicationContext(),Const.noConnection,Toast.LENGTH_SHORT);
                        toast.setGravity(Gravity.CENTER, 0, 0);
                        toast.show();
                    }

                    @Override
                    public void onResponse(@NonNull Call call, @NonNull Response response) throws IOException {
                        try{
                            String textResponse=response.body().source().readUtf8();
                            JSONArray products=new JSONArray(textResponse);
                            if(products.length()>0){
                            //if(false){
                                JSONObject product=products.getJSONObject(0);
                                String barCode=product.getString(Const.productBarCode);
                                String description=product.getString(Const.productDescription);
                                getActivity().runOnUiThread(new Runnable() {
                                    @Override
                                    public void run() {
                                        addProduct(barCode,description);
                                    }
                                });


                            }
                            else{
                                HashMap<String,String> params1=new HashMap<>();
                                params1=new HashMap<>();
                                params1.put(Const.searchParamName,productName);
                                NetworkCommunicator.get(Const.searchUrl, params1, new Callback() {
                                    @Override
                                    public void onFailure(@NonNull Call call, @NonNull IOException e) {
                                        Toast toast=Toast.makeText(getActivity().getApplicationContext(),Const.noConnection,Toast.LENGTH_SHORT);
                                        toast.setGravity(Gravity.CENTER, 0, 0);
                                        toast.show();
                                    }

                                    @Override
                                    public void onResponse(@NonNull Call call, @NonNull Response response) throws IOException {
                                        try {
                                            String textResponse=response.body().source().readUtf8();
                                            JSONArray products=new JSONArray(textResponse);
                                            String[] productDescriptions=new String[products.length()];
                                            ChoiceSelected[] productSelected=new ChoiceSelected[products.length()];
                                            for(int i=0;i<products.length();i++){
                                                JSONObject product= products.getJSONObject(i);
                                                String barCode=product.getString(Const.productBarCode);
                                                String description=product.getString(Const.productDescription);
                                                productDescriptions[i]=description;
                                                productSelected[i]=new ChoiceSelected() {
                                                    @Override
                                                    public void onSelected() {
                                                        addProduct(barCode,description);
                                                    }
                                                };




                                            }
                                            if(products.length()>0){
                                                SelectRecipeDialogFragment Dialog=new SelectRecipeDialogFragment(productDescriptions,productSelected);
                                                Dialog.show(getParentFragmentManager(),"DIALOG");

                                            }
                                            else{
                                               // Log.d("NO ENCONTRE","NO ENCONTRE");
                                                //Toast toast = new Toast(getActivity());
                                                //toast.setDuration(Toast.LENGTH_LONG);

                                               // LayoutInflater inflater = (LayoutInflater) getActivity().getSystemService(getActivity().LAYOUT_INFLATER_SERVICE);
                                               // View view = inflater.inflate(R.layout.toast_no_available, null);
                                                //toast.setView(view);
                                                //toast.show();
                                                //aqui tengo que poner lo de recipes
                                                //Toast.makeText(currentFragment.getActivity(),"Toast your message" ,Toast.LENGTH_SHORT).show();
                                                //Toast toast=Toast.makeText(getActivity(),Const.noAvailableProduct,Toast.LENGTH_SHORT);
                                                //toast.setGravity(Gravity.CENTER, 0, 0);
                                                //toast.show();
                                                //noProductToast.setGravity(Gravity.CENTER, 0, 0);
                                                //noProductToast.show();
                                                HashMap<String,String> params2=new HashMap<>();
                                                //params2.put(Const.recipeCreator,username);
                                                params2.put(Const.recipeName,productName);
                                                NetworkCommunicator.get(Const.recipeUrl, params2, new Callback() {
                                                    @Override
                                                    public void onFailure(@NonNull Call call, @NonNull IOException e) {

                                                    }

                                                    @Override
                                                    public void onResponse(@NonNull Call call, @NonNull Response response) throws IOException {
                                                        try{
                                                            String textResponse=response.body().source().readUtf8();
                                                            JSONArray products=new JSONArray(textResponse);

                                                            if(products.length()>0){
                                                                String[] productDescriptions=new String[products.length()];
                                                                ChoiceSelected[] productSelected=new ChoiceSelected[products.length()];
                                                                /*
                                                                JSONObject product=products.getJSONObject(0);
                                                                String recipeName=product.getString(Const.recipeObjectNameAttribute);
                                                                getActivity().runOnUiThread(new Runnable() {
                                                                    @Override
                                                                    public void run() {
                                                                        addRecipe(recipeName);
                                                                    }
                                                                });

                                                                 */
                                                                for(int i=0;i<products.length();i++){
                                                                    JSONObject product= products.getJSONObject(i);
                                                                    String recipeName=product.getString(Const.recipeObjectNameAttribute);
                                                                    String creator=product.getString(Const.recipeObjectCreatorAttribute);
                                                                    productDescriptions[i]=recipeName;
                                                                    productSelected[i]=new ChoiceSelected() {
                                                                        @Override
                                                                        public void onSelected() {
                                                                            addRecipe(recipeName,creator);
                                                                        }
                                                                    };
                                                                    SelectRecipeDialogFragment Dialog=new SelectRecipeDialogFragment(productDescriptions,productSelected);
                                                                    Dialog.show(getParentFragmentManager(),"DIALOG");




                                                                }


                                                            }
                                                            else{
                                                                getActivity().runOnUiThread(new Runnable() {
                                                                    @Override
                                                                    public void run() {
                                                                        noProductFound();
                                                                    }
                                                                });
                                                            }
                                                        }
                                                        catch (Exception e){}

                                                    }
                                                });

                                            }

                                        }
                                        catch (Exception e){
                                            String message=e.getMessage();
                                        }
                                    }
                                });
                            }
                        }
                        catch (Exception e){
                            String message=e.getMessage();
                        }

                    }
                });






            }
        });
        confirmButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(productsSelected.size()>0){
                    HashMap<String,ArrayList<String>> hash=new HashMap<>();
                    hash.put(Const.productKey,productsSelected);
                    hash.put(Const.recipeKey,recipesSelected);
                    hash.put(Const.creatorKey,recipesOwner);
                    viewModel.setProductList(hash);
                    productList.removeAllViews();
                    productsSelected=new ArrayList<>();
                    recipesSelected=new ArrayList<>();
                }
            }
        });

    }
    private boolean inProducts(String product){
        if (productsSelected.indexOf(product)>=0)return true;
        else return false;
    }


    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        viewModel=new ViewModelProvider(requireParentFragment()).get(productListViewModel.class);
        setListeners();

    }
    public void addProduct(String barsCode,String productName){
        //if(!inProducts(barsCode)){
            productsSelected.add(barsCode);
            DeleteButton button=new DeleteButton(getContext());
            productList.addView(button);
            button.setButtonText(productName);
            button.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    productList.removeView(button);
                    productsSelected.remove(barsCode);

                }
            });
            elementAdded(Const.productAdded);
      //  }

    }

    public void addRecipe(String recipeName,String creator){
        //if(!inProducts(barsCode)){
        recipesSelected.add(recipeName);
        recipesOwner.add(creator);
        DeleteButton button=new DeleteButton(getContext());
        productList.addView(button);
        button.setButtonText(recipeName);
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                productList.removeView(button);
                recipesSelected.remove(recipeName);
                recipesOwner.remove(creator);

            }
        });
        elementAdded(Const.recipeAdded);
        //  }

    }
    public void noProductFound(){

        Toast toast=Toast.makeText(getActivity(),Const.noAvailableProduct,Toast.LENGTH_SHORT);
        toast.setGravity(Gravity.CENTER, 0, 0);
        toast.show();
    }
    public void elementAdded(String text){
        Toast toast=Toast.makeText(getActivity(),text,Toast.LENGTH_SHORT);
        toast.setGravity(Gravity.CENTER, 0, 0);
        toast.show();
    }


}