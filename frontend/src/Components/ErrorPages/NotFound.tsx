import {Link} from "react-router-dom";

const NotFoundComponent = ()=>{
    return (
        <div className={"container"}>
            <div className={"row justify-content-center"} >
                <div className={"col-3 homepageForm"}>
                    <h1>404</h1>
                    <h1>Stránka nenájdená</h1>
                    <Link to={"/"}>Domov</Link>
                </div>
            </div>
        </div>
    );
}

export default NotFoundComponent;