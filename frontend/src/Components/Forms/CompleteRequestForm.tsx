import React, {useEffect, useState} from "react";
import {Button} from "react-bootstrap";
import {useNavigate, useParams} from "react-router-dom";
import {UtilService} from "../../Service/UtilService";
import validator from "validator";
import isNumeric = validator.isNumeric;
import TextField from "@material-ui/core/TextField";
import DatePicker from "react-datepicker";

const CompleteRequestForm = () => {
    let navigate = useNavigate();
    const { caseIndex } = useParams();
    let [requestPrices, setRequestPrices]: [number[], any] = useState([0, 0])
    let [licensePlate, setLicensePlate]: [string, any] = useState("")
    let [isYearly, setIsYearly]: [boolean, any] = useState(false)
    const [startDate, setStartDate]: [any, any] = useState(new Date());

    useEffect(() => {
        if(caseIndex === undefined || !isNumeric(caseIndex) || Number(caseIndex) < 0 || Number(caseIndex) > 11)
            navigate("/404")
        else{
            setRequestPrices([UtilService.CalculateTaxAmountForRequest(Number(caseIndex), false), UtilService.CalculateTaxAmountForRequest(Number(caseIndex), true)])
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
                        <TextField label={"EČV vozidla"} onChange={(e) => {setLicensePlate(e.target.value)}} value={licensePlate}/>
                        <DatePicker selected={startDate} onChange={(date) => {setStartDate(date)}}/>
                        <Button className={"me-2"} onClick={() => navigate("/profil/ziadosti")} variant={"danger"}>Zrušiť</Button>
                        <Button className={"me-2"} type={"submit"} variant={"success"}>Potvrdiť</Button>
                    </form>
                </div>
            </div>
        </div>
    )
}

export default CompleteRequestForm;