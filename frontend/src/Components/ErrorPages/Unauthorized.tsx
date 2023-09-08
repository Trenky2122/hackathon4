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
      <div className={"Unauthorized p-4"}>
          <h1>401: {localization.unauthorized}</h1>
          <Link to={"/"}>{localization.goHome}</Link>
      </div>
    );
}

export default UnauthorizedComponent;