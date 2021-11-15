package ac.cr.tec.NutriTec.network;

import android.content.Context;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.util.Log;

import androidx.annotation.NonNull;

import org.json.JSONObject;

import java.io.IOException;
import java.security.cert.CertificateException;
import java.util.Map;

import javax.net.ssl.HostnameVerifier;
import javax.net.ssl.SSLContext;
import javax.net.ssl.SSLSession;
import javax.net.ssl.SSLSocketFactory;
import javax.net.ssl.TrustManager;
import javax.net.ssl.X509TrustManager;

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
    private static OkHttpClient client=getClient().build();


    /**
     * process a get request to the given url with the params,the callback given will be used in the function returning
     * @param url   String url
     * @param params    Map<String,String> params
     * @param responseCallback  callback
     */
    public static void get(String url, Map<String,String> params, Callback responseCallback) {
        //client.proxy();
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
    public static void put(String url,JSONObject body,Callback callback) throws IOException {
        if(url==null || body==null)return;
        client.proxy();
        RequestBody requestBody = RequestBody.create( body.toString(),
                MediaType.parse("application/json"));
        Request request = new Request.Builder()
                .url(url)
                .put(requestBody)
                .addHeader("Content-Type", "application/json")
                .build();

        //Response response=client.newCall(request).execute();
        client.newCall(request).enqueue(callback);
        ///return null;





    }
    /**
     * put request
     * @param url String url
     * @param body  JSONObject body
     * @return  a Response
     * @throws IOException
     */
    public static void post(String url,JSONObject body,Callback callback) throws IOException {
        if(url==null || body==null)return;
        client.proxy();
        RequestBody requestBody = RequestBody.create( body.toString(),
                MediaType.parse("application/json"));
        Request request = new Request.Builder()
                .url(url)
                .post(requestBody)
                .addHeader("Content-Type", "application/json")
                .build();

        //Response response=client.newCall(request).execute();
        client.newCall(request).enqueue(callback);
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
    public static OkHttpClient.Builder getClient(){
        Context context = null;

        try {
            // Create a trust manager that does not validate certificate chains
            final TrustManager[] trustAllCerts = new TrustManager[]{
                    new X509TrustManager() {
                        @Override
                        public void checkClientTrusted(java.security.cert.X509Certificate[] chain, String authType) throws CertificateException {
                        }

                        @Override
                        public void checkServerTrusted(java.security.cert.X509Certificate[] chain, String authType) throws CertificateException {
                        }

                        @Override
                        public java.security.cert.X509Certificate[] getAcceptedIssuers() {
                            return new java.security.cert.X509Certificate[]{};
                        }
                    }
            };

            // Install the all-trusting trust manager
            final SSLContext sslContext = SSLContext.getInstance("SSL");
            sslContext.init(null, trustAllCerts, new java.security.SecureRandom());

            // Create an ssl socket factory with our all-trusting manager
            final SSLSocketFactory sslSocketFactory = sslContext.getSocketFactory();

            OkHttpClient.Builder builder = new OkHttpClient.Builder();
            builder.sslSocketFactory(sslSocketFactory, (X509TrustManager) trustAllCerts[0]);
            builder.hostnameVerifier(new HostnameVerifier() {
                @Override
                public boolean verify(String hostname, SSLSession session) {
                    return true;
                }
            });
            return builder;
        } catch (Exception e) {
            throw new RuntimeException(e);
        }


    }



}