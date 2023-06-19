import React, { useState, useEffect } from 'react';
import { Container, Typography, Box, Paper } from '@mui/material';
import axios from 'axios';

const OverviewPage = () => {

  // format numbers!! math right?

  const [incomeTotal, setIncomeTotal] = useState(0);
  const [maaserTotal, setMaaserTotal] = useState(0);
  const [maaserObligated, setMaaserObligated] = useState(0);
  const [remainingMaaser, setRemainingMaaser] = useState(0);

  const getIncomeTotal = async () => {
    const { data } = await axios.get("api/income/getincometotal");
    setIncomeTotal(data);
  }

  const getMaaseTotal = async () => {
    const { data } = await axios.get("api/maaser/getmaasertotal");
    setMaaserTotal(data);
  }

  const getMaaserObligated = async () => {
    const { data } = await axios.get("api/income/getmaaserobligated");
    data < 0 ? setMaaserObligated(o) : setMaaserObligated(data)
  }

  const getRemainigMaaser = async () => {
    const { data } = await axios.get("api/income/getremainigmaaser");
    data < maaserObligated ? setRemainingMaaser(0) : setRemainingMaaser(data)
    // setRemainingMaaser(data)

  }

  useEffect(() => {
    getIncomeTotal();
    getMaaseTotal();
    getMaaserObligated();
    getRemainigMaaser();

  })
  return (
    <Container
      maxWidth="md"
      sx={{
        display: 'flex',
        flexDirection: 'column',
        justifyContent: 'center',
        alignItems: 'center',
        height: '80vh',
        textAlign: 'center'
      }}
    >
      <Paper elevation={3} sx={{ padding: '120px', borderRadius: '15px' }}>
        <Typography variant="h2" gutterBottom>
          Overview
        </Typography>
        <Box sx={{ marginBottom: '20px' }}>
          <Typography variant="h5" gutterBottom>
            Total Income: ${incomeTotal.toFixed(2)}
          </Typography>
          <Typography variant="h5" gutterBottom>
            Total Maaser: ${maaserTotal.toFixed(2)}
          </Typography>
        </Box>
        <Box>
          <Typography variant="h5" gutterBottom>
            Maaser Obligated: ${maaserObligated.toFixed(2)}
          </Typography>
          <Typography variant="h5" gutterBottom>
            Remaining Maaser obligation: ${remainingMaaser.toFixed(2)}
          </Typography>
        </Box>
      </Paper>
    </Container>
  );
}

export default OverviewPage;
