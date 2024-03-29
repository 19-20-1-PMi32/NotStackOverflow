import * as React from 'react';
import { Formik, Form, Field } from 'formik';
import { Link } from 'react-router-dom';

import { InputField, Button, H2, TextButton, WarningButton } from 'components';
import { styled } from 'theme';
import { validationUtil } from 'utils';
import { RouteConsts } from 'consts';
import { IUserDataSelect, HandleUpdateUserInfoAction } from 'store/domains';

const Wrapper = styled.div`
  display: flex;
  max-width: 650px;
  margin: 0 auto;

  .user-info {
    width: 450px;
    margin: 0 auto;
    text-align: left;
    padding: 0 40px;
    margin-top: 100px;

    .title {
      margin-bottom: 20px;
      color: ${({ theme }) => theme.color.primary};
      border-bottom: 1px solid ${({ theme }) => theme.color.primary};
      font-weight: normal;
    }

    .form-field {
      margin-bottom: 10px;
      text-align: left;
    }

    .submit-button {
      margin: 10px;
    }

    .align-buttons {
      width: 100%;
      display: flex;
      justify-content: center;
    }
  }

  .navigation-buttons {
    max-width: 250px;
    margin: 0 auto;
    text-align: left;
    padding: 0 40px;
    margin-top: 165px;

    .button {
      width: 100%;
      margin-bottom: 20px;
    }
  }
`;

interface IProfile {
  userData: IUserDataSelect;
  handleUpdateUserInfoAction: HandleUpdateUserInfoAction;
}

const LoginForm: React.FC<IProfile> = ({ userData, handleUpdateUserInfoAction }) => {
  const { id, ...initialValues } = userData;

  return (
    <Wrapper>
      <div className="user-info">
        <H2 className="title">General information</H2>
        <Formik
          initialValues={initialValues}
          enableReinitialize={true}
          onSubmit={(values) => {
            handleUpdateUserInfoAction(values as any);
          }}
        >{({ resetForm }) => (
          <Form>
            <Field
              component={InputField}
              label="Name"
              name="name"
              placeholder="Enter your name"
              validate={validationUtil.required}
            />
            <Field
              component={InputField}
              label="Surname"
              name="surname"
              placeholder="Enter your surname"
              validate={validationUtil.required}
            />
            <Field
              component={InputField}
              label="Nickname"
              name="nickName"
              placeholder="Enter your username"
              validate={validationUtil.required}
            />
            <Field
              component={InputField}
              label="Email"
              name="email"
              placeholder="Enter your email"
              validate={validationUtil.required}
            />
            <Field
              component={InputField}
              label="Job"
              name="job"
              placeholder="Enter your Job place"
            />
            <div className="align-buttons">
              <Button className="submit-button" type="submit">Save</Button>
              <TextButton
                type="button"
                className="submit-button"
                onClick={() => {
                  resetForm(initialValues)
                }}
              >
                Discard changes
            </TextButton>
            </div>
          </Form>
        )}
        </Formik>
      </div>
      <div className="navigation-buttons">
        <Link to={RouteConsts.AskQuestion}> 
          <WarningButton className="button">Ask Question</WarningButton>
        </Link>
        <Link to={`/user/${id}/questions`}> 
          <Button className="button">Your Questions</Button>
        </Link>
      </div>
    </Wrapper>
  )
};

export default LoginForm;
