package ac.cr.tec.NutriTec.screens;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.EditText;

import com.google.android.material.button.MaterialButton;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.util.HashMap;

import ac.cr.tec.NutriTec.Const.Const;
import ac.cr.tec.NutriTec.R;
import ac.cr.tec.NutriTec.encryptation.MD5;
import ac.cr.tec.NutriTec.network.NetworkCommunicator;
import okhttp3.Call;
import okhttp3.Callback;
import okhttp3.Response;

import android.preference.PreferenceManager;

public class Login extends AppCompatActivity {

    private EditText username;
    private EditText password;
    private MaterialButton loginButton;
    private Login currentClass;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        build();

    }
    public void build(){
        currentClass=this;
        getInstances();
        setOnClick();

    }
    public void getInstances(){
        username=findViewById(R.id.login_entry_user);
        password=findViewById(R.id.login_entry_password);
        loginButton=findViewById(R.id.login_button);
    }
    public void setOnClick(){
        loginButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String user=username.getText().toString();
                String pass=password.getText().toString();
                HashMap<String,String> parameters=new HashMap<>();
                parameters.put(Const.loginUserParamName,user);
                parameters.put(Const.loginPasswordParamName, MD5.toMD5(pass));
                NetworkCommunicator.get(Const.loginUrl, parameters, new Callback() {
                    @Override
                    public void onFailure(@NonNull Call call, @NonNull IOException e) {
                        Log.d("FALLO","FALLO");
                        //Intent intent=new Intent(currentClass, MainView.class);
                        //startActivity(intent);

                    }

                    @Override
                    public void onResponse(@NonNull Call call, @NonNull Response response) throws IOException {
                        //Log.d("EXITO","EXITO");
                        String textResponse=response.body().source().readUtf8();
                        try {
                            JSONArray jsonResponse=new JSONArray(textResponse);
                            if(jsonResponse.length()!=0){
                                SharedPreferences preferences=PreferenceManager.getDefaultSharedPreferences(currentClass);
                                SharedPreferences.Editor editor=preferences.edit();
                                editor.putString(Const.user,user);
                                editor.commit();
                                Intent intent=new Intent(currentClass, MainView.class);
                                startActivity(intent);
                            }
                            else{
                               // Intent intent=new Intent(currentClass, MainView.class);
                                //startActivity(intent);
                            }
                        }
                        catch (JSONException exception){
                           // Intent intent=new Intent(currentClass, MainView.class);
                            //startActivity(intent);
                        }


                    }
                });
            }
        });
    }

}