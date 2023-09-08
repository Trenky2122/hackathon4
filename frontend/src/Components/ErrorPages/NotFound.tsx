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
      <div className={"notFound p-4"}>
          <h1>404: {localization.notFound}</h1>
          <Link to={"/"}>{localization.goHome}</Link>
      </div>
    );
}

export default NotFoundComponent;