import React from "react";
import {Button} from "react-bootstrap";
import {Link, useNavigate} from "react-router-dom";

const PermitNotGrantedComponent = () => {
    let navigate = useNavigate();
    return (
        <div className={"container"}>
            <div className={"row justify-content-center"} >
                <div className={"col-6 homepageForm"}>
                    <h1 className={"mb-4"}>Prepáčte, na povolenie nemáte nárok</h1>
                    <Button className={"me-2"} variant={"success"} onClick={() => navigate("/")}>Domov</Button>    </div>
            </div>
        </div>
    )
}

export default PermitNotGrantedComponent;