import { SideMenu } from "../components/SideMenu";
import { GoogleMap, useJsApiLoader, Marker } from '@react-google-maps/api';
import { mapOptions, mapSize } from "../configs/mapConfigs";
import { Company } from "../interfaces/Company";

interface HomeProps {
    companies: Company[];
}

export default function Home({companies}: HomeProps) {
    const { isLoaded } = useJsApiLoader({
        id: 'google-map-script',
        googleMapsApiKey: "AIzaSyAfK14Wxe-6oILjFosaEks5cYU0IkXhrZk"
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

            <div className="map">
                <GoogleMap
                    mapContainerStyle={mapSize}
                    center={center}
                    zoom={15}
                    options={mapOptions}
                >
                    {companies.map(company => (
                        <Marker key={company.id}
                                position={{
                                    lat: company.latitude,
                                    lng: company.longitude
                                }}
                        />
                    ))}
                </GoogleMap>
            </div>
        </>
    )
}

export async function getServerSideProps() {
    const response = await fetch('https://unisantos-interdisciplinar-server.azurewebsites.net/companies?Latitude=-23.94647831242809&Longitude=-46.3222917531583&Distance=1');

    const data = await response.json();

    return {
        props: {
            companies: data.data
        }
    }
}