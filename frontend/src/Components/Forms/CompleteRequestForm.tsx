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
    let [licensePlate, setLicensePlate]: [string, any] = useState("")
    let [startDate, setStartDate]: [string, any] = useState("")
    let [isYearly, setIsYearly]: [boolean, any] = useState(false)

    useEffect(() => {
        if(caseIndex === undefined || !isNumeric(caseIndex) || Number(caseIndex) < 0 || Number(caseIndex) > 11)
            navigate("/404")
        else{
            setRequestPrices([UtilService.CalculateTaxAmountForRequest(Number(caseIndex), false), UtilService.CalculateTaxAmountForRequest(Number(caseIndex), true)])
        }
    }, [caseIndex])

    const handleSubmit = (e: any) => {
        e.preventDefault()
        //Call backend to register a request
    }

    useEffect(() => {
        console.log(startDate)
    }, [startDate])

    return (
        <div className={"container"}>
            <div className={"row justify-content-center"} >
                <div className={"col-6 homepageForm"}>
                    <form onSubmit={handleSubmit}>
                        <h1 style={{marginBottom: "30px"}}>Dokončenie požidadavky o židaosť</h1>
                        <div className={"row mb-2"}>
                            <div className={"col-6"}>
                                    <Button className={"me-2"} onClick={() => setIsYearly(false)} variant={"primary"}>Deň</Button>
                                    <Button className={"me-2"} disabled={requestPrices[1] === 0} onClick={() => setIsYearly(true)} variant={"secondary"}>Rok</Button>
                            </div>
                            <div className={"col-6"}>
                                <TextField label={"Cena"} disabled value={!isYearly ? requestPrices[0] : requestPrices[1] }/>
                            </div>
                        </div>
                        <div className={"row mb-4"}>
                            <div className={"col-6"}>
                                <TextField  label={"EČV vozidla"} value={licensePlate} onChange={(e) => {setLicensePlate(e.target.value)}}/>
                            </div>
                            <div className={"col-6"}>
                                <TextField type={"date"} style={{marginTop: "15px", width: "195px"}} value={startDate} onChange={(e) => {setStartDate(e.target.value)}}/>
                            </div>
                        </div>
                        <Button className={"me-2"} onClick={() => navigate("/profil/ziadosti")} variant={"danger"}>Zrušiť</Button>
                        <Button className={"me-2"} type={"submit"} variant={"success"}>Potvrdiť</Button>
                    </form>
                </div>
            </div>
        </div>
    )
}

export default CompleteRequestForm;