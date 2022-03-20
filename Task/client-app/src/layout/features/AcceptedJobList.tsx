import react from 'React';
import { Item, Segment } from 'semantic-ui-react';
import { Job } from '../../models/jobs';
import AcceptedJobDetails from './AcceptedJobDetails';

interface Props{
    jobs: Job[];
}

export default function AcceptedJobList({jobs}: Props){
    return (
        <Item.Group>
            {jobs.map(job => (
                <Item key={job.id}>
                    <Item.Content>
                        <AcceptedJobDetails job={job} />
                    </Item.Content>
                </Item>
            ))}
        </Item.Group>
    )
}