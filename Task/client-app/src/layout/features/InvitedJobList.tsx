import react from 'React';
import { Item, Segment } from 'semantic-ui-react';
import { Job } from '../../models/jobs';
import InvitedJobDetails from './InvitedJobDetails';

interface Props{
    jobs: Job[];
    setJobStatus:(id: string, status: string) => void;
}

export default function InvitedJobList({jobs, setJobStatus}: Props){
    return (
        <Item.Group>
            {jobs.map(job => (
                <Item key={job.id}>
                    <Item.Content>
                        <InvitedJobDetails job={job} setJobStatus={setJobStatus}/>
                    </Item.Content>
                </Item>
            ))}
        </Item.Group>
    )
}