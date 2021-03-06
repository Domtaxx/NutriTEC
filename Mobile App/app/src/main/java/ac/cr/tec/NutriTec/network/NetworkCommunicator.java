package ac.cr.tec.NutriTec.network;

import android.content.Context;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.util.Log;

import androidx.annotation.NonNull;

import org.json.JSONObject;

import java.io.IOException;
import java.util.Map;

import okhttp3.Call;
import okhttp3.Callback;
import okhttp3.FormBody;
import okhttp3.Headers;
import okhttp3.HttpUrl;
import okhttp3.MediaType;
import okhttp3.OkHttp;
import okhttp3.OkHttpClient;
import okhttp3.Request;
import okhttp3.RequestBody;
import okhttp3.Response;


public class NetworkCommunicator {
    private static OkHttpClient client=new OkHttpClient();

    /**
     * process a get request to the given url with the params,the callback given will be used in the function returning
     * @param url   String url
     * @param params    Map<String,String> params
     * @param responseCallback  callback
     */
    public static void get(String url, Map<String,String> params, Callback responseCallback) {
      //  client.proxy();
        HttpUrl.Builder httpBuilder = HttpUrl.parse(url).newBuilder();
        if (params != null) {
            for(Map.Entry<String, String> param : params.entrySet()) {
                httpBuilder.addQueryParameter(param.getKey(),param.getValue());
            }
        }
        Request request = new Request.Builder().url(httpBuilder.build()).build();
        client.newCall(request).enqueue(responseCallback);
    }

    /**
     * put request
     * @param url String url
     * @param body  JSONObject body
     * @return  a Response
     * @throws IOException
     */
    public static void put(String url,JSONObject body) throws IOException {
        if(url==null || body==null)return;
       // client.proxy();
        RequestBody requestBody = RequestBody.create( body.toString(),
                MediaType.parse("application/json"));
        Request request = new Request.Builder()
                .url(url)
                .put(requestBody)
                .addHeader("Content-Type", "application/json")
                .build();

            //Response response=client.newCall(request).execute();
            client.newCall(request).enqueue(new Callback() {
                @Override
                public void onFailure(@NonNull Call call, @NonNull IOException e) {

                }

                @Override
                public void onResponse(@NonNull Call call, @NonNull Response response) throws IOException {
                    Log.d("PUT","EXIto");
                }
            });
            ///return null;





    }
    public static boolean isNetworkAvailable(final Context context) {
        final ConnectivityManager cm = (ConnectivityManager)
                context.getSystemService(Context.CONNECTIVITY_SERVICE);
        if (cm == null) return false;
        final NetworkInfo networkInfo = cm.getActiveNetworkInfo();
        // if no network is available networkInfo will be null
        // otherwise check if we are connected
        return (networkInfo != null && networkInfo.isConnected());
    }


}
