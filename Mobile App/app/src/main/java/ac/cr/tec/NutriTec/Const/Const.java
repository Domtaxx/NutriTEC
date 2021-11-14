package ac.cr.tec.NutriTec.Const;

public class Const {
    //base url
    public static final String urlSite="https://25.92.13.1:44352";

    //login related
    public static final String user="username";
    public static final String loginUrl=urlSite+"/Login/Client";
    public static final String loginUserParamName="Correo";
    public final static String loginPasswordParamName="Contra";

    //search related
    public static final String searchUrl=urlSite+"/Producto/buscar";
    public static final String searchParamName="desc";
    public static final String searchBarsParam="Codigo";


    //product object related
    public static final String productBarCode="codigoBarras";
    public static final String productDescription="descripcion";
    public static final String noAvailableProduct="No se encontro ningun producto";

    //Reci



}
