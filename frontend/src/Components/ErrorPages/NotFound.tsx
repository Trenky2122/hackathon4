import {Link} from "react-router-dom";
import LocalizedStrings from "react-localization";

const NotFoundComponent = ()=>{
    let localization = new LocalizedStrings({
        en: {
            goHome: "Back to homepage",
            notFound: "Page not found"
        },
        sk: {
            goHome: "Späť domov",
            notFound: "Stránka nenájdená"
        }
    });

    return (
        <div className={"container"}>
            <div className={"row justify-content-center"} >
                <div className={"col-3 homepageForm"}>
                    <h1>404</h1>
                    <h1>{localization.notFound}</h1>
                    <Link to={"/"}>{localization.goHome}</Link>
                </div>
            </div>
        </div>
    );
}

export default NotFoundComponent;