import {Link} from "react-router-dom";
import LocalizedStrings from "react-localization";

const UnauthorizedComponent = ()=>{
    let localization = new LocalizedStrings({
        en: {
            goHome: "Back to homepage",
            unauthorized: "Unauthorized"
        },
        sk: {
            goHome: "Späť domov",
            unauthorized: "Neoprávnený prístup"
        }
    });

    return (
        <div className={"container"}>
            <div className={"row justify-content-center"} >
                <div className={"col-3 homepageForm"}>
                    <h1>401</h1>
                    <h1>{localization.unauthorized}</h1>
                    <Link to={"/"}>{localization.goHome}</Link>
                </div>
            </div>
        </div>
    );
}

export default UnauthorizedComponent;