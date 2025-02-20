import React, { useState } from 'react';
import { Box, Tab, Tabs } from '@mui/material';
import LeadList from './LeadList';

const LeadTabs: React.FC = () => {
    const [tabIndex, setTabIndex] = useState(0);

    const handleTabChange = (event, newIndex) => {
        setTabIndex(newIndex);
    };
    return (
        <Box
            sx={{
                backgroundColor: "#ddd",
                width: "80%",
                height: "90vh",
                margin: "0 auto",
                padding: 2,
                borderRadius: 2,
                boxShadow: 2,
                overflowY: "auto",
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
    );
};

export default LeadTabs;