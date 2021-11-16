package ac.cr.tec.NutriTec.Const;

public class Const {
    //base url
    public static final String urlSite="https://nutritecsqlapi.azurewebsites.net";

    //login related
    public static final String user="username";
    public static final String fullName="fullName";
    public static final String firstName="primerNom";
    public static final String secondName="segNom";
    public static final String lastName="primerApellido";
    public static final String secondLastName="segApellido";
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
    public static final String creatorKey="creator";
    public static final String recipeUrl=urlSite+"/Receta/Busqueda";
    public static final String recipeObjectNameAttribute="nombre";
    public static final String recipeObjectCreatorAttribute="correoCreador";
    public static final String recipeObjectProductAttribute="productos";


    //meals
    public static final String mealText="Meal";
    public static final String breakfast="Desayuno";
    public static final String snackMorning="Merienda 1";
    public static final String lunch="Almuerzo";
    public static final String snackEvening="Merienda 2";
    public static final String dinner="Cena";

    //recipes dailyConsumeAdd
    public static final String dailyUrl=urlSite+"/Reportes/Productos";
    public static final String dailyRecipeUrl=urlSite+"/Reportes/Recetas";
    public static final String dailyBarCode="codigoBarras";
    public static final String dailyRecipeName="nombreReceta";
    public static final String dailyRecipeCreator="correoCreador";
    public static final String dailyUser="correoCliente";
    public static final String dailyDate="fecha";
    public static final String dailyTime="tiempo";
    public static final String dailyAccepted="Agregado ";
    public static final String dailyFailed="Fallo en agregar ";


    //recipes creation
    public static String addRecipeUrl=urlSite+"/Receta/Crear";
    public static String addRecipeName="nombre";
    public static String addRecipeEmail="correoCreador";
    public static String addRecipeProduct="productos";
    public static String addRecipeSuccess="Reseta Añadida con exito";
    public static String addRecipeError="No se pudo agregar la receta";

    //profile
    public static String measuresUrl=urlSite+"/Cliente/Medidas/Reciente";
    public static final String measureEmail="correo";
    public static final String measureHips="cadera";
    public static final String measureMusclePercentage="porcentajeMusculo";
    public static final String measureFatPercentage="porcentajeGrase";
    public static final String measureNape="cuello";
    public static final String measureWaist="cintura";
    public static final String measureIMC="imc";
    public static final String measureWeight="peso";


    //Errores
    public static final String noConnection="No hay conexion";


}
