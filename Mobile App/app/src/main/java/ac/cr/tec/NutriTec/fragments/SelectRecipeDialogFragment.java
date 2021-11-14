package ac.cr.tec.NutriTec.fragments;

import android.app.AlertDialog;
import android.app.Dialog;
import android.content.Context;
import android.content.DialogInterface;
import android.os.Bundle;
import android.view.MenuItem;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.DialogFragment;

import ac.cr.tec.NutriTec.R;
import ac.cr.tec.NutriTec.interfaces.ChoiceSelected;

public class SelectRecipeDialogFragment extends DialogFragment {
    private String[] list;
    private ChoiceSelected[] selected;
    public SelectRecipeDialogFragment(String[] list, ChoiceSelected[] selected){
        this.list=list;
        this.selected=selected;
    }
    @NonNull
    @Override
    public Dialog onCreateDialog(Bundle savedInstanceState) {
        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
        builder.setTitle(R.string.recipe_title)
                .setItems(list, new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        selected[which].onSelected();
                    }
                });
        return builder.create();
    }

}
