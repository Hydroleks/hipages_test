import React from 'react'
import { Tab } from 'semantic-ui-react'
import { Job } from '../../models/jobs';
import AcceptedJobList from './AcceptedJobList';
import InvitedJobList from './InvitedJobList';

interface Props{
  invitedJobs: Job[];
  acceptedJobs: Job[];
  setJobStatus:(id: string, status: string) => void;
}

export default function Dashboard({invitedJobs, acceptedJobs, setJobStatus}: Props){
    return(
        <Tab menu={{ color:'orange', secondary: true, pointing: true }} panes={[
          {
            menuItem: 'Invited Jobs',
            render: () => <Tab.Pane attached={false}>
              <InvitedJobList jobs={invitedJobs} setJobStatus={setJobStatus}/>
            </Tab.Pane>,
          },
          {
            menuItem: 'Accepted Jobs',
            render: () => <Tab.Pane attached={false}>
              <AcceptedJobList jobs={acceptedJobs}/>
            </Tab.Pane>,
          },
        ]}>
        </Tab>
    )
};