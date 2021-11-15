package ac.cr.tec.NutriTec.fragments;

import android.content.SharedPreferences;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;
import androidx.lifecycle.ViewModelProvider;

import android.preference.PreferenceManager;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import java.util.ArrayList;

import ac.cr.tec.NutriTec.Const.Const;
import ac.cr.tec.NutriTec.R;
import ac.cr.tec.NutriTec.viewModel.productListViewModel;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link DailyMealFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class DailyMealFragment extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;
    private String mealTime;
    private TextView title;


    private productListViewModel viewModel;


    public DailyMealFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment DailyMealFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static DailyMealFragment newInstance(String param1, String param2) {
        DailyMealFragment fragment = new DailyMealFragment();
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
        View view=inflater.inflate(R.layout.fragment_daily_meal, container, false);;

        return view;
    }
    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        SharedPreferences preferences= PreferenceManager.getDefaultSharedPreferences(getContext());
        title=view.findViewById(R.id.meal_name);
        mealTime=preferences.getString(Const.mealText,"");
        title.setText(mealTime);
        viewModel=new ViewModelProvider(this).get(productListViewModel.class);
        viewModel.getProductList().observe(getViewLifecycleOwner(),element->{
            //Log.d("IMPORTANTE",element.toString());
            //mealTimeName.setText(element.get(0));
            //aqui van los parametros


        });
    }
    public void processProduct(ArrayList<String> products,String MealTime){

    }


}