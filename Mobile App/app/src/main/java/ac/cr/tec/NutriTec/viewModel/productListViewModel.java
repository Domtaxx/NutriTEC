package ac.cr.tec.NutriTec.viewModel;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import java.util.ArrayList;
import java.util.HashMap;

public class productListViewModel extends ViewModel {
    private final MutableLiveData<HashMap<String,ArrayList<String>>> productList=new MutableLiveData<>();
    //private final MutableLiveData<ArrayList<String>> recipesList=new Mutabl

    public LiveData<HashMap<String,ArrayList<String>>>  getProductList(){
        return productList;
    }
    public void setProductList(HashMap<String,ArrayList<String>> products){
        productList.setValue(products);
    }

}
