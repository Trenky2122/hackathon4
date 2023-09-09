import React, {useEffect, useState} from "react";
import {Button} from "react-bootstrap";
import {useNavigate, useParams} from "react-router-dom";
import {UtilService} from "../../Service/UtilService";
import validator from "validator";
import isNumeric = validator.isNumeric;
import TextField from "@material-ui/core/TextField";

const CompleteRequestForm = () => {
    let navigate = useNavigate();
    const { caseIndex } = useParams();
    let [requestPrices, setRequestPrices]: [number[], any] = useState([0, 0])
    let [displayedPrice, setDisplayedPrice]: [number, any] = useState(0)
    let [isYearly, setIsYearly]: [boolean, any] = useState(false)

    useEffect(() => {
        if(caseIndex === undefined || !isNumeric(caseIndex) || Number(caseIndex) < 0 || Number(caseIndex) > 11)
            navigate("/404")
        else{
            let dayPrice = UtilService.CalculateTaxAmountForRequest(Number(caseIndex), false)
            let yearPrice = UtilService.CalculateTaxAmountForRequest(Number(caseIndex), true)
            console.log(dayPrice, yearPrice)
            setRequestPrices([dayPrice, yearPrice])
        }
    }, [caseIndex])

    const handleSubmit = (e: any) => {
        e.preventDefault()
    }

    return (
        <div className={"container"}>
            <div className={"row justify-content-center"} >
                <div className={"col-6 homepageForm"}>
                    <form onSubmit={handleSubmit}>
                        <h1 style={{marginBottom: "30px"}}>Dokončenie požidadavky o židaosť</h1>
                        <Button className={"me-2"} onClick={() => setIsYearly(false)} variant={"primary"}>Deň</Button>
                        <Button className={"me-2"} disabled={requestPrices[1] === 0} onClick={() => setIsYearly(true)} variant={"primary"}>Rok</Button>
                        <TextField label={"Cnea"} disabled value={!isYearly ? requestPrices[0] : requestPrices[1] }/>
                        <Button className={"me-2"} onClick={() => navigate("/profil/ziadosti")} variant={"danger"}>Zrušiť</Button>
                        <Button className={"me-2"} type={"submit"} variant={"success"}>Potvrdiť</Button>
                    </form>
                </div>
            </div>
        </div>
    )
}

export default CompleteRequestForm;