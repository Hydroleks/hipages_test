import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import React from 'react';
import { Card, Button, Grid } from 'semantic-ui-react';
import { Job } from '../../models/jobs';
import { faBriefcase, faLocationPin, faUserAstronaut } from '@fortawesome/free-solid-svg-icons'
import moment from 'moment';
import { currencyFormat } from '../../Util/utils';

interface Props{
    job: Job;
    setJobStatus:(id: string, status: string) => void;
}

export default function InvitedJobDetails({job, setJobStatus}: Props){
    return (
      <Card fluid color='orange'>
        <Card.Content>
          <Grid>
            <Grid.Column verticalAlign={'middle'} textAlign={'center'}>
              <FontAwesomeIcon icon={faUserAstronaut} />
            </Grid.Column>
            <Grid.Column width={8}>
              <Card.Header>
              <span style={{fontWeight: 'bold'} }>{job.contactName}</span>
              </Card.Header>
              <Card.Meta>
                <span> {moment(job.created).format("MMMM D Y @ LT")}</span>
              </Card.Meta>
            </Grid.Column>
          </Grid>
        </Card.Content>
        <Card.Content>
          <Card.Meta>
            <FontAwesomeIcon icon={faLocationPin} /> {job.suburb} &nbsp;
            <FontAwesomeIcon icon={faBriefcase} /> {job.category} &nbsp;
            <span style={{fontWeight: 'bold'} }>Job ID:</span><span>{job.id}</span>
          </Card.Meta>
        </Card.Content>
        <Card.Content>
          <Card.Description>
            {job.description}
          </Card.Description>
        </Card.Content>
        <Card.Content extra>
          <Grid>
            <Grid.Column width={4}>
              <Button.Group fluid>
                <Button onClick={() => setJobStatus(job.id, 'accepted')} positive content='Accept' />
                <Button onClick={() => setJobStatus(job.id, 'declined')} content='Decline' />
              </Button.Group>
            </Grid.Column>
            <Grid.Column width={12} verticalAlign='middle'>
              <span style={{fontWeight: 'bold'} }>{currencyFormat(job.price)}</span> <span>Lead Invitation</span>
            </Grid.Column>
          </Grid>
        </Card.Content>
      </Card>
    );
}