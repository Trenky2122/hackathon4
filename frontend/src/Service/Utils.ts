export class Utils {
    public static UserIsLogged(): boolean {
        return localStorage.getItem("loggedIn") == "true";
    }
}