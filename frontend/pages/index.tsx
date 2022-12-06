import { SideMenu } from "../components/SideMenu";
import { GoogleMap, useJsApiLoader, Marker } from '@react-google-maps/api';
import { mapOptions, mapSize } from "../configs/mapConfigs";
import { Company } from "../interfaces/Company";
import { useEffect, useState } from "react";
import { animated, useSpring } from "react-spring";
import { Button } from '@mui/material'
import {api} from "../services";
import {TagsSection} from "../interfaces/TagsSection";
import qs from "qs";
import Link from "next/link";

interface HomeProps {
    tagsSections: TagsSection[];
    googleMapsApiKey: string;
}

interface GetCompaniesResponse {
    data: Company[];
}

export default function Home({ tagsSections, googleMapsApiKey }: HomeProps) {
    const [companyModalOpened, setCompanyModalOpened] = useState(false);
    const [selectedCompany, setSelectedCompany] = useState<Company>();

    const [latitude, setLatitude] = useState(0);
    const [longitude, setLongitude] = useState(0);
    const [companies, setCompanies] = useState<Company[]>([]);
    const [distance, setDistance] = useState(10);
    const [selectedTags, setSelectedTags] = useState<number[]>([]);

    useEffect(() => {
        navigator.geolocation.getCurrentPosition(position => {
            setLatitude(position.coords.latitude);
            setLongitude(position.coords.longitude);
        });
    }, []);

    useEffect(() => {
        api.get<GetCompaniesResponse>('/companies', {
            params: {
                latitude,
                longitude,
                distance,
                tags: selectedTags
            },
            paramsSerializer: {
                serialize: params => qs.stringify(params, { arrayFormat: 'repeat' })
            }
        }).then(response => setCompanies(response.data.data));
    }, [latitude, longitude, distance, selectedTags]);

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
            <SideMenu tagsSections={tagsSections} selectedTags={selectedTags} setSelectedTags={setSelectedTags} distance={distance} setDistance={setDistance} />

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
                        <img
                            className='logoBoxCompanyContainer'
                            src={selectedCompany?.imagePreviewUrl}
                            alt={`Imagem do estabelecimento ${selectedCompany?.name}`}
                        />

                        <div className="companyContainerInfos">
                            <div className="companyContainerItem companyContainerName">
                                <b>{selectedCompany?.name}</b>
                            </div>

                            <div className="companyContainerItem companyContainerAddress">
                                {selectedCompany?.address.street} - {selectedCompany?.address.number} - {selectedCompany?.address.neighborhood}
                            </div>

                            <div className="companyContainerItem companyContainerRating">
                                {selectedCompany?.rating ? selectedCompany?.rating : "Sem avaliações"}
                            </div>
                        </div>

                    </div>

                    <Button variant="contained" className="companyRedirectButton">
                        <Link style={{
                            textDecoration: 'none',
                            color: 'white'
                        }} href={`/companies/${selectedCompany?.id}`}>MAIS INFORMAÇÕES</Link>
                    </Button>
                </div>
            </animated.div>
        </>
    )
}

interface GetTagsResponse {
    data: TagsSection[];
}

export async function getServerSideProps() {
    const response = await api.get<GetTagsResponse>('/tags');

    return {
        props: {
            tagsSections: response.data.data,
            googleMapsApiKey: process.env.GOOGLE_MAPS_API_KEY
        }
    }
}