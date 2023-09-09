import React from "react";
import {Button} from "react-bootstrap";
import {useNavigate} from "react-router-dom";

const PermitNotGrantedComponent = () => {
    let navigate = useNavigate();
    return (
        <div>
            <div>Prepáčte, na povolenie nemáte nárok</div>
            <Button className={"me-2"} variant={"success"} onClick={() => navigate("/")}>Homepage</Button>
        </div>
    )
}

export default PermitNotGrantedComponent;