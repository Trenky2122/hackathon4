import {Link} from "react-router-dom";

const UnauthorizedComponent = ()=>{
    return (
        <div className={"container"}>
            <div className={"row justify-content-center"} >
                <div className={"col-3 homepageForm"}>
                    <h1>401</h1>
                    <h1>Neoprávnený prístup</h1>
                    <Link to={"/"}>Späť domov</Link>
                </div>
            </div>
        </div>
    );
}

export default UnauthorizedComponent;