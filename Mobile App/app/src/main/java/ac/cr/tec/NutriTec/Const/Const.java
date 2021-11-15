package ac.cr.tec.NutriTec.Const;

public class Const {
    //base url
    public static final String urlSite="https://nutritecsqlapi.azurewebsites.net";

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
    public static final String noAvailableProduct="No se encontro ningun producto o receta";
    public static final String productAdded="Se agrego el producto";
    //Recipe creator
    public static final String recipeCreator="creator";
    public static final String recipeName="name";
    public static final String recipeAdded="Se agrego la receta";

    //hash keys
    public static final String productKey="product";
    public static final String recipeKey="recipe";
    public static final String recipeUrl=urlSite+"/Receta/ByName";
    public static final String recipeObjectNameAttribute="nombre";


    //comidas
    public static final String mealText="Meal";
    public static final String breakfast="Desayuno";
    public static final String snackMorning="Merienda 1";
    public static final String lunch="Almuerzo";
    public static final String snackEvening="Merienda 2";
    public static final String dinner="Cena";


    //Errores
    public static final String noConnection="No hay conexion";


}
