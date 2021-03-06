package ac.cr.tec.NutriTec.fragments;

import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.LinearLayout;

import com.google.android.material.button.MaterialButton;

import java.util.ArrayList;

import ac.cr.tec.NutriTec.R;
import ac.cr.tec.NutriTec.customViews.DeleteButton;
import ac.cr.tec.NutriTec.viewModel.productListViewModel;

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
    private ArrayList<String> productsSelected;
    private MaterialButton addProductButton;
    private MaterialButton confirmButton;
    private EditText productInputName;
    private LinearLayout productList;
    private productListViewModel viewModel;


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
        productsSelected=new ArrayList<>();
        getInstances(currentView);
        setListeners();
        return currentView;
    }
    private void getInstances(View view){
        addProductButton=view.findViewById(R.id.add_product_button);
        confirmButton=view.findViewById(R.id.save_recipe);
        productInputName=view.findViewById(R.id.product_label);
        productList=view.findViewById(R.id.product_list);
    }
    private void setListeners(){
        addProductButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                final String productName=productInputName.getText().toString();
                if(!inProducts(productName)){
                    productsSelected.add(productName);
                    DeleteButton button=new DeleteButton(getContext());
                    productList.addView(button);
                    button.setButtonText(productName);
                    button.setOnClickListener(new View.OnClickListener() {
                        @Override
                        public void onClick(View view) {
                            productList.removeView(button);
                            productsSelected.remove(productName);

                        }
                    });
                }

            }
        });
        confirmButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(productsSelected.size()>0){
                    viewModel.setProductList(productsSelected);
                    productList.removeAllViews();
                    productsSelected=new ArrayList<>();
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

    }
}