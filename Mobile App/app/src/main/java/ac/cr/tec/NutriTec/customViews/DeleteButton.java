package ac.cr.tec.NutriTec.customViews;

import android.content.Context;
import android.util.AttributeSet;
import android.view.LayoutInflater;
import android.widget.LinearLayout;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;


import com.google.android.material.button.MaterialButton;

import ac.cr.tec.NutriTec.R;

public class DeleteButton extends LinearLayout {
    private MaterialButton button;

    public DeleteButton(Context context) {
        super(context);
        build(context);
    }

    public DeleteButton(Context context, @Nullable AttributeSet attrs) {
        super(context, attrs);
        build(context);
    }

    public DeleteButton(Context context, @Nullable AttributeSet attrs, int defStyleAttr) {
        super(context, attrs, defStyleAttr);
        build(context);
    }

    public DeleteButton(Context context, AttributeSet attrs, int defStyleAttr, int defStyleRes) {
        super(context, attrs, defStyleAttr, defStyleRes);
        build(context);
    }


    public void build(Context context){
        LayoutInflater.from(context).inflate(R.layout.delete_button,this);
        button=findViewById(R.id.delete_button);

    }

    @Override
    public void setOnClickListener(@Nullable OnClickListener l) {
        button.setOnClickListener(l);
    }
}
