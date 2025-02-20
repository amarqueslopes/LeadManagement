import React, { useState } from 'react';
import { Box, Container, Tab, Tabs } from '@mui/material';
import LeadList from './components/LeadList';

const App: React.FC = () => {
    const [tabIndex, setTabIndex] = useState(0);

    const handleTabChange = (event, newIndex) => {
        setTabIndex(newIndex);
    };
    return (
        <Container
            sx={{
                width: "80vw",
                height: "95vh",
                display: "flex",
                justifyContent: "center",
                alignItems: "center",
            }}
        >
            <Box
                sx={{
                    backgroundColor: "#ddd",
                    width: "80%",
                    margin: "0 auto",
                    padding: 2,
                    borderRadius: 2,
                    boxShadow: 2,
                }}
            >
                <Tabs
                    value={tabIndex}
                    onChange={handleTabChange}
                    centered
                    variant="fullWidth"
                    TabIndicatorProps={{
                        style: { backgroundColor: "orange" },
                    }}
                    sx={{ backgroundColor: "white" }}
                >
                    <Tab label="Invited" sx={{
                        flexGrow: 1,
                        textTransform: "none",
                        fontWeight: "bold"
                    }} />
                    <Tab label="Accepted" sx={{
                        flexGrow: 1,
                        textTransform: "none",
                        fontWeight: "bold"
                    }} />
                </Tabs>
                <Box sx={{ mt: 2 }}>
                    {tabIndex === 0 && <LeadList status="Invited" />}
                    {tabIndex === 1 && <LeadList status="Accepted" />}
                </Box>
            </Box>
        </Container>
    );
};

export default App;