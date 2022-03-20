import { faBriefcase, faEnvelope, faLocationPin, faPhone, faUserAstronaut } from '@fortawesome/free-solid-svg-icons';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import moment from 'moment';
import React from 'react';
import { Card, Grid } from 'semantic-ui-react';
import { Job } from '../../models/jobs';
import { currencyFormat } from '../../Util/utils';

interface Props{
    job: Job;
}

export default function AcceptedJobDetails({job}: Props){
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
                <span> {moment(job.updated).format("MMMM D Y @ LT")}</span>
              </Card.Meta>
            </Grid.Column>
          </Grid>
        </Card.Content>
        <Card.Content>
          <Card.Meta>
            <FontAwesomeIcon icon={faLocationPin} /> {job.suburb} &nbsp;
            <FontAwesomeIcon icon={faBriefcase} /> {job.category} &nbsp;
            <span style={{fontWeight: 'bold'} }>Job ID:</span><span>{job.id}</span> &nbsp;
            <span style={{fontWeight: 'bold'} }>{currencyFormat(job.price)}</span> <span>Lead Invitation</span>
          </Card.Meta>
        </Card.Content>
        <Card.Content>
          <FontAwesomeIcon icon={faPhone} />
          <a style={{color: 'orange', fontWeight: 'bold'}} href={"tel:" + job.contactPhone }>{job.contactEmail}</a> &nbsp;
          <FontAwesomeIcon icon={faEnvelope} />
          <a style={{color: 'orange', fontWeight: 'bold'}} href={"mailto:{{" + job.contactEmail + "}}"}>{job.contactEmail}</a>
          <Card.Description>
            {job.description}
          </Card.Description>
        </Card.Content>
      </Card>
    );
}