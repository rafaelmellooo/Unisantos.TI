import ArrowBackIcon from '@mui/icons-material/ArrowBack';
import { TextField } from '@mui/material';
import React from 'react';
import { IMaskInput } from 'react-imask';
import { InputTelefone } from '../../components/InputTelefone';


export default function Home() {
    return (
        <>
            <div className="registerHeader">
                <ArrowBackIcon />
                <div className='registerTitle'>Nova Empresa</div>
            </div>

            <div className="registerForm">
                <TextField
                    label="Nome"
                    variant="standard"
                    className="registerField"
                />

                <TextField
                    label="Descrição"
                    variant="standard"
                    className="registerField"
                    multiline
                />

                <InputTelefone />

                <TextField
                    label="Instagram"
                    variant="standard"
                    className="registerField"
                    multiline
                />

                <TextField
                    label="Facebook"
                    variant="standard"
                    className="registerField"
                    multiline
                />
            </div>
        </>
    )
}