import React from 'react';
import { Container } from '@mui/material';
import LeadTabs from './components/LeadTabs';
import { ThemeProvider, createTheme } from "@mui/material/styles";

const theme = createTheme({
    palette: {
        primary: {
            main: "#ff9800",
        },
        secondary: {
            main: "#d5d5d5",
        },
        text: {
            primary: "#333333",
            secondary: "#ff9800",
        },
    },
});

const App: React.FC = () => {
    return (
        <ThemeProvider theme={theme}>
            <Container
                sx={{
                    width: "80vw",
                    height: "95vh",
                    display: "flex",
                    justifyContent: "center",
                    alignItems: "center",
                }}
            >
                <LeadTabs />
            </Container>
        </ThemeProvider>
    );
};

export default App;