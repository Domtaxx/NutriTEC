package ac.cr.tec.NutriTec.screens;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.view.GravityCompat;
import androidx.drawerlayout.widget.DrawerLayout;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;
import androidx.navigation.ui.NavigationUI;

import android.os.Bundle;
import android.util.Log;

import android.view.View;
import android.widget.ImageView;

import com.google.android.material.navigation.NavigationView;

import ac.cr.tec.NutriTec.R;

public class MainView extends AppCompatActivity {
    private NavigationView navigationBar;
    private ImageView barIcon;
    private DrawerLayout drawerLayout;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main_view);
        buildInstances();
    }
    public void buildInstances(){
        barIcon=(ImageView) findViewById(R.id.bar_button);
        navigationBar=(NavigationView)findViewById(R.id.navigation);
        drawerLayout=findViewById(R.id.drawer);
        barIcon.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                openNavigationBar();

            }
        });
        NavController navController= Navigation.findNavController(this,R.id.navHostFragment);
        NavigationUI.setupWithNavController(navigationBar,navController);

    }
    public void openNavigationBar(){
        drawerLayout.openDrawer(GravityCompat.START);
        //Log.d("LOG","click");
    }
}