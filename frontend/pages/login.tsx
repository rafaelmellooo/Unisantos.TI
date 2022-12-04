import { AccountCircle, VisibilityOff } from '@mui/icons-material'
import { Button, InputAdornment, TextField } from '@mui/material'
import Image from 'next/image'
import Logo from '../public/logo.png'

export default function Login() {
    return (
        <>
            <Image
                className='logo-box'
                src={Logo}
                alt="logo"
            />

            <div className="login-box">
                <TextField
                    label="Usuário"
                    InputProps={{
                        endAdornment: (
                            <InputAdornment position="end">
                                <AccountCircle />
                            </InputAdornment>
                        )
                        ,
                    }}
                    variant="standard"
                    className="login-input"
                />

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
                    className="login-input"
                />

                <Button variant="contained" className="login-button">
                    ENTRAR
                </Button>
                <Button variant="contained" className="login-button">
                    CADASTRE-SE
                </Button>
            </div>
        </>
    )
}