import LocalizedStrings from "react-localization";
import React from "react";
import {useNavigate} from "react-router-dom";
import Button from "react-bootstrap/esm/Button";
import BackgroundImage from "../../Images/BackgroundImage";

const HomeComponent = () => {
    let navigate = useNavigate();
    const localization = new LocalizedStrings({
        en: {
            title: "Welcome.",
        },
        sk: {
            title: "Vitajte",
        }
    })
    return (
        <div>
            <div className={"container"}>
                <div className={"row justify-content-center"} >
                    <div className={"col-3 homepageForm"}>
                        <h1 style={{marginBottom: "30px"}}>{localization.title} </h1>
                        <Button className={"me-2"} variant={"primary"} onClick={() => navigate("/registracia/ziskanieEmailu")}>Registrácia</Button>
                        <Button className={"me-2"} variant={"light"} onClick={() => navigate("/prihlasenie")}>Prihlásiť sa</Button>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default HomeComponent;