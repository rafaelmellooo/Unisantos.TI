import Image from 'next/image'
import Unknown from '../public/unknown-user.png'
import { ArrowBack, VisibilityOff } from '@mui/icons-material'
import { InputAdornment, MenuItem, Select, TextField, Button, InputLabel } from '@mui/material';

export default function SignUp() {
    return (
        <>
            <div className="signUp-header">
                <div className='arrow'><ArrowBack /></div>
                Cadastro
            </div>
            <div className='signUp-main'>
                <div className='signUp-image-container'>
                    <Image
                        className='signUp-image'
                        width={30}
                        src={Unknown}
                        alt="logo"
                    />
                </div>
                <div className='signUp-form'>
                    <TextField
                        label="Nome"
                        variant="standard"
                        className="signUp-input"
                    />
                    <TextField
                        label="Sobrenome"
                        variant="standard"
                        className="signUp-input"
                    />

                    <TextField
                        label="Data de Nascimento"
                        variant="standard"
                        className="signUp-input"
                    />
                    <InputLabel id="demo-simple-select-label"></InputLabel>
                    <Select
                        labelId="demo-simple-select-label"
                        label="Gênero"
                        className="signUp-input"
                        variant='standard'
                    >
                        <MenuItem>Masculino</MenuItem>
                        <MenuItem>Feminino</MenuItem>
                        <MenuItem>Outro</MenuItem>
                    </Select>
                    <TextField
                        label="CPF"
                        variant="standard"
                        className="signUp-input-large"
                    />
                    <TextField
                        label="E-mail"
                        variant="standard"
                        className="signUp-input-large"
                    />{/* 
                    <InputTelefone>
                    </InputTelefone> */}
                    <TextField
                        label="Senha"
                        type="password"
                        InputProps={{
                            endAdornment: (
                                <InputAdornment position="end">
                                    <VisibilityOff />
                                </InputAdornment>
                            )
                            ,
                        }}
                        variant="standard"
                        className="signUp-input-large"
                    />
                    <TextField
                        label="Confirmar Senha"
                        type="password"
                        InputProps={{
                            endAdornment: (
                                <InputAdornment position="end">
                                    <VisibilityOff />
                                </InputAdornment>
                            )
                            ,
                        }}
                        variant="standard"
                        className="signUp-input-large"
                    />

                    <Button variant="contained" className="login-button">
                        CADASTRE-SE
                    </Button>
                </div>
            </div>
        </>
    );
}