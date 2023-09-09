import React from "react";
import {Button} from "react-bootstrap";
import {useNavigate} from "react-router-dom";

const DeterminateCategoryForm = () => {
    let navigate = useNavigate();
    return (
        <div>
            <div>Zistenie skupiny</div>
            <Button className={"me-2"} variant={"danger"} onClick={() => navigate("/ziadost/zamietnuta")}>Vstup mi nebol povolený</Button>
            <Button className={"me-2"} variant={"success"} onClick={() => navigate("/registracia/ziskanieEmailu")}>Skipujem proces určovania, žiadam o vstup</Button>
        </div>
    )
}

export default DeterminateCategoryForm;