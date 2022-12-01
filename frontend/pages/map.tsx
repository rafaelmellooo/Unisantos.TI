import SideMenu from "../components/SideMenu";
import { GoogleMap, useJsApiLoader, Marker } from '@react-google-maps/api';
import { mapOptions, mapSize } from "./mapConfigs";

export async function getStaticProps() {

    const data = await fetch('https://unisantos-interdisciplinar-server.azurewebsites.net/companies?Latitude=-23.94647831242809&Longitude=-46.3222917531583&Distance=10');

    const places = await data.json();

    return {
        props: { places }
    }
}

export default function Home({ places }) {
    const { isLoaded } = useJsApiLoader({
        id: 'google-map-script',
        googleMapsApiKey: "AIzaSyAfK14Wxe-6oILjFosaEks5cYU0IkXhrZk"
    });

    const center = {
        lat: -23.94647831242809,
        lng: -46.3222917531583
    };

    return (
        <>
            <SideMenu />

            <div className="map">
                {isLoaded ? (
                    <GoogleMap
                        mapContainerStyle={mapSize}
                        center={center}
                        zoom={15}
                        options={mapOptions}
                    >
                        {places.data.map(place => (
                            <Marker key={place.id}
                                position={{
                                    lat: place.latitude,
                                    lng: place.longitude
                                }}
                            />
                        ))}
                    </GoogleMap>
                ) : <></>}
            </div>
        </>
    )
}