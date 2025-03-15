CREATE USER postgres WITH PASSWORD '1234567';

CREATE DATABASE SurveyTesting
OWNER = postgres
ENCODING = 'UTF8'
TABLESPACE = pg_default
CONNECTION LIMIT = -1;

GRANT ALL PRIVILEGES ON DATABASE SurveyTesting TO postgres;

CREATE TABLE Surveys (
    Id SERIAL PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Description TEXT,
    CreatedAt TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP,
    DeletedAt TIMESTAMP
);

CREATE TABLE Questions (
    Id SERIAL PRIMARY KEY,
    Text TEXT NOT NULL,
    Order INT NOT NULL DEFAULT 0,
    SurveyId INTEGER REFERENCES Surveys(Id) ON DELETE CASCADE,
    CreatedAt TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP,
    DeletedAt TIMESTAMP
);

CREATE TABLE Answers (
    Id SERIAL PRIMARY KEY,
    Text TEXT NOT NULL,
    Order INT NOT NULL DEFAULT 0,
    QuestionId INTEGER REFERENCES Questions(Id) ON DELETE CASCADE,
    CreatedAt TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP,
    DeletedAt TIMESTAMP
);

CREATE TABLE Interviews (
    Id SERIAL PRIMARY KEY,
    UserId INTEGER NOT NULL,
    SurveyId INTEGER REFERENCES Surveys(Id) ON DELETE CASCADE,
    PassingDate TIMESTAMP NOT NULL,
    CompletionDate TIMESTAMP,
    CreatedAt TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP,
    DeletedAt TIMESTAMP
);

CREATE TABLE Results (
    Id SERIAL PRIMARY KEY,
    InterviewId INTEGER REFERENCES Interviews(Id) ON DELETE CASCADE,
    QuestionId INTEGER REFERENCES Questions(Id),
    AnswerId INTEGER REFERENCES Answers(Id),
    AnswerText TEXT,
    CreatedAt TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt TIMESTAMP,
    DeletedAt TIMESTAMP
);

CREATE INDEX idx_surveys_name ON Surveys(Name);
CREATE INDEX idx_questions_surveyid ON Questions(SurveyId);
CREATE INDEX idx_answers_questionid ON Answers(QuestionId);
CREATE INDEX idx_interviews_userid_surveyid ON Interviews(UserId, SurveyId);
CREATE INDEX idx_results_interviewid_questionid ON Results(InterviewId, QuestionId);
