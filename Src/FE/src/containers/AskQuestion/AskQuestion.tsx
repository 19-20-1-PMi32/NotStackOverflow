import * as React from 'react';
import { Formik, Form, Field } from 'formik';

import { InputField, WarningButton, H2, TextAreaField } from 'components';
import { styled } from 'theme';
import { validationUtil } from 'utils';

const Wrapper = styled.div`
  max-width: 650px;
  margin: 0 auto;
  text-align: left;
  padding: 0 40px;
  margin-top: 100px;

  .title {
    fotn-size: 22px;
    margin-bottom: 20px;
  }

  .form-field {
    margin-bottom: 10px;
    text-align: left;
  }

  .submit-button {
    margin: 10px auto;
    width: 150px;
  }

  .text-area {
    padding-left: 10px;
    padding-top: 10px;
    min-height: 50px;
    resize: vertical;
    height: 250px;
  }
`;

const AskQuestionContainer = () => {
  return (
    <Wrapper>
      <H2 className="title">Ask a question</H2>
      <Formik
        initialValues={{
          title: '',
          text: ''
        }}
        onSubmit={() => undefined}
      >{() => (
        <Form>
          <Field
            component={InputField}
            label="Title"
            name="title"
            placeholder="Enter yout title"
            validate={validationUtil.required}
          />
          <Field
            component={TextAreaField}
            label="Body"
            name="text"
            placeholder=""
            validate={validationUtil.required}
            className="text-area"
          />
          <WarningButton className="submit-button" type="submit">Post Your Question</WarningButton>
        </Form>
      )}
      </Formik>
    </Wrapper>
  )
};

export default AskQuestionContainer;
