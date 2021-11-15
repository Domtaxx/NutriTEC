package ac.cr.tec.NutriTec.fragments;

import android.content.SharedPreferences;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.fragment.NavHostFragment;

import android.os.ConditionVariable;
import android.preference.PreferenceManager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.google.android.material.button.MaterialButton;

import ac.cr.tec.NutriTec.Const.Const;
import ac.cr.tec.NutriTec.R;


/**
 * A simple {@link Fragment} subclass.
 * Use the {@link MealSelector#newInstance} factory method to
 * create an instance of this fragment.
 */
public class MealSelector extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;
    private MaterialButton breakfastButton;
    private MaterialButton morningSnackButton;
    private MaterialButton lunchButton;
    private MaterialButton eveningSnackButton;
    private MaterialButton dinnerButton;
    private TextView title;
    private NavController navController;



    public MealSelector() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment MealSelector.
     */
    // TODO: Rename and change types and number of parameters
    public static MealSelector newInstance(String param1, String param2) {
        MealSelector fragment = new MealSelector();
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

        return inflater.inflate(R.layout.fragment_meal_selector, container, false);
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        getInstances(view);
        navController= NavHostFragment.findNavController(this);
        setListener();
    }
    public void getInstances(View view){
        breakfastButton=view.findViewById(R.id.breakfast_button);
        morningSnackButton=view.findViewById(R.id.morning_snack_button);
        lunchButton=view.findViewById(R.id.lunch_button);
        eveningSnackButton=view.findViewById(R.id.evening_snack_button);
        dinnerButton=view.findViewById(R.id.dinner_button);
        title=view.findViewById(R.id.Select_meal_title);
    }
    public void setListener(){
        breakfastButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                replaceFragment(Const.breakfast);
            }
        });
        morningSnackButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                replaceFragment(Const.snackMorning);
            }
        });
        lunchButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                replaceFragment(Const.lunch);
            }
        });
        eveningSnackButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                replaceFragment(Const.snackEvening);
            }
        });
        dinnerButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
               //replaceFragment(Const.dinner);
            }
        });
    }
    public void replaceFragment(String food){
        /*
        DailyMealFragment fragment = new DailyMealFragment();
        fragment.setMealTime(food);
        //title.setText("");
        FragmentManager fm = getActivity().getSupportFragmentManager();

        FragmentTransaction transaction = fm.beginTransaction();
        transaction.replace(R.id.navHostFragment, fragment,null);
        transaction.commit();
         */
        SharedPreferences preferences= PreferenceManager.getDefaultSharedPreferences(getContext());
        SharedPreferences.Editor editor=preferences.edit();
        editor.putString(Const.mealText,food);
        editor.commit();
        navController.navigate(R.id.action_navigation_daily_meals_to_dailyMealFragment);






    }


}