import { SideMenu } from "../components/SideMenu";
import { GoogleMap, useJsApiLoader, Marker } from '@react-google-maps/api';
import { mapOptions, mapSize } from "../configs/mapConfigs";
import { Company } from "../interfaces/Company";
import { useEffect, useState } from "react";
import { animated, useSpring } from "react-spring";
import Image from 'next/image'
import SemImagem from '../public/semimagem.png'
import { Button } from '@mui/material'
import {api} from "../services";

interface HomeProps {
    companies: Company[];
    googleMapsApiKey: string;
}

export default function Home({ companies, googleMapsApiKey }: HomeProps) {
    const [companyModalOpened, setCompanyModalOpened] = useState(true);
    const [selectedCompany, setSelectedCompany] = useState<Company>();

    const handleCompanyModalToggle = (index: number) => {
        setSelectedCompany(companies[index]);
    }

    useEffect(() => {
        setCompanyModalOpened(companyModalOpened => !companyModalOpened);
    }, [selectedCompany])

    const { bottom } = useSpring({
        from: { bottom: "-100%" },
        bottom: companyModalOpened ? "0" : "-100%"
    });

    const { isLoaded } = useJsApiLoader({
        id: 'google-map-script',
        googleMapsApiKey: googleMapsApiKey
    });

    if (!isLoaded) {
        return <div>Loading...</div>
    }

    const center = {
        lat: -23.94647831242809,
        lng: -46.3222917531583
    };

    return (
        <>
            <SideMenu />

            <GoogleMap
                mapContainerStyle={mapSize}
                center={center}
                zoom={15}
                options={mapOptions}
            >
                <Marker
                    position={{
                        lat: -23.96340247042726,
                        lng: -46.3190778340487
                    }}
                />
                {companies.map((company, index) => (
                    <Marker key={company.id}
                        position={{
                            lat: company.latitude,
                            lng: company.longitude
                        }}
                        onClick={() => handleCompanyModalToggle(index)}
                    />
                ))}
            </GoogleMap>

            <animated.div style={{ bottom: bottom }} className="companyInfo">
                <div className="companyClose" onClick={() => { setCompanyModalOpened(companyModalOpened => !companyModalOpened) }} />

                <div className="companyContainer">
                    <div className="companyContainerHeader">
                        <Image
                            className='logoBoxCompanyContainer'
                            src={SemImagem}
                            alt="logo"
                        />

                        <div className="companyContainerInfos">
                            <div className="companyContainerItem companyContainerName">
                                <b>{selectedCompany?.name}</b>
                            </div>

                            <div className="companyContainerItem companyContainerAddress">
                                {selectedCompany?.address.street} - {selectedCompany?.address.number} - {selectedCompany?.address.neighborhood}
                            </div>

                            <div className="companyContainerItem companyContainerRating">
                                {selectedCompany?.rating}(3,5)
                            </div>
                        </div>

                    </div>

                    <Button variant="contained" className="companyRedirectButton">
                        MAIS INFORMAÇÕES
                    </Button>
                </div>
            </animated.div>
        </>
    )
}

interface AxiosResponse {
    data: Company[];
}

export async function getServerSideProps() {
    const response = await api.get<AxiosResponse>('/companies?Latitude=-23.94647831242809&Longitude=-46.3222917531583&Distance=10');

    return {
        props: {
            companies: response.data.data,
            googleMapsApiKey: process.env.GOOGLE_MAPS_API_KEY
        }
    }
}