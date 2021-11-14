package ac.cr.tec.NutriTec.viewModel;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import java.util.ArrayList;

public class productListViewModel extends ViewModel {
    private final MutableLiveData<ArrayList<String>> productList=new MutableLiveData<>();

    public LiveData<ArrayList<String>>  getProductList(){
        return productList;
    }
    public void setProductList(ArrayList<String> products){
        productList.setValue(products);
    }

}
