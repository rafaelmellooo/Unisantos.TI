import {Dispatch, SetStateAction, useState} from "react";
import { useSpring, animated } from "react-spring";
import {Chip, InputAdornment, TextField} from '@mui/material'
import {AccountCircle, Close, FilterAlt} from "@mui/icons-material";
import {TagsSection} from "../interfaces/TagsSection";

interface SideMenuProps {
    tagsSections: TagsSection[];
    selectedTags: number[];
    setSelectedTags: Dispatch<SetStateAction<number[]>>;
    distance: number;
    setDistance: Dispatch<SetStateAction<number>>;
}

export const SideMenu = ({tagsSections, selectedTags, setSelectedTags, distance, setDistance}: SideMenuProps) => {

    const [opened, setOpened] = useState(false);

    const handleMenuToggle = () => {
        setOpened(opened => !opened);
    }

    const { left } = useSpring({
        from: { left: "-100%" },
        left: opened ? "0" : "-100%"
    });

    const handleSelectedTag = (tag: number) => {
        if (selectedTags.includes(tag)) {
            setSelectedTags(selectedTags.filter(selectedTag => selectedTag !== tag));
        }
        else {
            setSelectedTags([...selectedTags, tag]);
        }
    }

    return (
        <>
            <div className="menu-button" id="menuButton" onClick={(handleMenuToggle)}>
                <FilterAlt />
            </div>

            <animated.div style={{ left: left }} className="sideMenu">
                <div className="items-container">
                    <div className="filtros-close-container">
                        Filtros
                        <Close />
                    </div>
                    <TextField
                        label={`Distância (${distance}km)`}
                        variant="filled"
                        type='range'
                        value={distance}
                        style={{
                            width: '100%',
                        }}
                        onChange={event => setDistance(Number(event.target.value))}
                    />
                    {
                        tagsSections?.map(tagsSection => (
                            <div key={tagsSection.title}>
                                <div className="filter-section">{tagsSection.title}</div>
                                <div className="filter-chip-container">
                                    {
                                        tagsSection.tags.map(tag => (
                                            <Chip style={{
                                                backgroundColor: selectedTags.includes(tag.id) ? '#9dbef5' : '#fff',}
                                            } onClick={() => handleSelectedTag(tag.id)} key={tag.id} label={tag.name} size="small" className='filter-chip' />
                                        ))
                                    }
                                </div>
                            </div>
                        ))
                    }
                </div>

                <div className="close-conainer" onClick={handleMenuToggle} />
            </animated.div>
        </>
    );
};