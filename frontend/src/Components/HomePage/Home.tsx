import React from "react";
import {useNavigate} from "react-router-dom";
import Button from "react-bootstrap/esm/Button";

const HomeComponent = () => {
    let navigate = useNavigate();
    return (
        <div>
            <div className={"container"}>
                <div className={"row justify-content-center"} >
                    <div className={"col-3 homepageForm"}>
                        <h1 style={{marginBottom: "30px"}}>Vitajte</h1>
                        <Button className={"me-2"} variant={"primary"} onClick={() => navigate("/registracia/ziskanieEmailu")}>Registrácia</Button>
                        <Button className={"me-2"} variant={"light"} onClick={() => navigate("/prihlasenie")}>Prihlásiť sa</Button>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default HomeComponent;