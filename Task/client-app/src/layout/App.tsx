import React, { useEffect, useState } from 'react';
import '../App.css';
import axios from 'axios';
import { Header } from 'semantic-ui-react';
import { Job } from '../models/jobs';
import Dashboard from './features/Dashboard';

function App() {
  // would need to use setMemo I believe. Have yet to learn how that works and how to use it.
  const [invitedJobs, setInvitedJobs] = useState<Job[]>([]);
  const [acceptedJobs, setAcceptedJobs] = useState<Job[]>([]);

  useEffect(() => {
    axios.get<Job[]>("http://localhost:5233/api/Job").then(response => {
      var newJobs = response.data.filter(job => job.status === "new");
      setInvitedJobs(newJobs);
    });
  }, []);

  useEffect(() => {
    axios.get<Job[]>("http://localhost:5233/api/Job").then(response => {
      var accepted = response.data.filter(job => job.status === "accepted")
      setAcceptedJobs(accepted);
    });
  }, []);

  function setJobStatus(id: string, status: string){
    if(status === 'accepted')
    {
      axios.put(`http://localhost:5233/api/Job/${id}/${'accepted'}`).then(response => {
        setAcceptedJobs([...acceptedJobs, ...invitedJobs.filter(job => job.id === id)]);
        setInvitedJobs([...invitedJobs.filter(job => job.id !== id)]);
      });
    }
    else if(status === 'declined')
    {
      axios.put(`http://localhost:5233/api/Job/${id}/${'declined'}`).then(response => {
        setInvitedJobs([...invitedJobs.filter(job => job.id !== id)]);
      });
    }
  }

  return (
    <>
      <Header as='h2' icon='list' content='Jobs'/>
      <Dashboard invitedJobs={invitedJobs} acceptedJobs={acceptedJobs} setJobStatus={setJobStatus}/>
    </>
  );
}

export default App;
