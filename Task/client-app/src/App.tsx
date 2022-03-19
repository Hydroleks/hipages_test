import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { Job } from './models/jobs';
import { Header, List } from 'semantic-ui-react';

function App() {
  // this will need to be job invitations according to the requirements. will need to introduce new controller on back end
  const [jobs, setJobs] = useState<Job[]>([]);

  useEffect(() => {
    axios.get<Job[]>("http://localhost:5233/api/Job").then(response => {
      console.log(response);
      setJobs(response.data);
    });
  }, []);

  return (
    <div>
      <Header as='h2' icon='users' content='Jobs'/>
      <List>
        {
          jobs.map((job: Job) => (
            <List.Item key={job.id}>
              {job.contactName}
            </List.Item>
          ))
        }
      </List>
    </div>
  );
}

export default App;
