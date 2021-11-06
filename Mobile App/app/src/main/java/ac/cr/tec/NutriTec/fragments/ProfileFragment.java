package ac.cr.tec.NutriTec.fragments;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import ac.cr.tec.NutriTec.R;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link ProfileFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class ProfileFragment extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;
    private TextView HeightText;
    private TextView WaistText;
    private TextView WeightText;
    private TextView HipsText;
    private TextView IMCText;
    private TextView NapeText;
    private final String heightUnit="m";
    private final String bodyMeasureUnits="cm";
    private final String weightMeasureUnits="kg";

    public ProfileFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment ProfileFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static ProfileFragment newInstance(String param1, String param2) {
        ProfileFragment fragment = new ProfileFragment();
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
        View view=inflater.inflate(R.layout.fragment_profile, container, false);
        getInstances(view);
        return view;
    }
    public void getInstances(View view){
        HeightText=view.findViewById(R.id.profile_height);
        WaistText=view.findViewById(R.id.profile_waist_size);
        WeightText=view.findViewById(R.id.profile_weight);
        HipsText=view.findViewById(R.id.profile_hips);
        IMCText=view.findViewById(R.id.profile_IMC);
        NapeText=view.findViewById(R.id.profile_nape);
    }
    public void updateHeightText(String heightMeasure){
        String newText= getString(R.string.profile_height)+" "+heightMeasure+heightUnit;
        HeightText.setText(newText);
    }
    public void updateWaistText(String waistMeasure){
        String newText= getString(R.string.profile_waist)+" "+waistMeasure+bodyMeasureUnits;
        WaistText.setText(newText);
    }
    public void updateWeightText(String weight){
        String newText= getString(R.string.profile_weight)+" "+weight+weight;
        WeightText.setText(newText);
    }
    public void updateHipsText(String hipsMeasure){
        String newText= getString(R.string.profile_hips)+" "+hipsMeasure+bodyMeasureUnits;
       HipsText.setText(newText);
    }
    public void updateIMCText(String IMC){
        String newText= getString(R.string.profile_IMC)+" "+IMC;
        IMCText.setText(newText);
    }
    public void updateNapeText(String napeMeasure){
        String newText= getString(R.string.profile_nape)+" "+napeMeasure+bodyMeasureUnits;
        IMCText.setText(newText);
    }



}