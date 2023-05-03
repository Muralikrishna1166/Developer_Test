import React, { useState } from "react";
import "./LoginAttemptList.css";

const LoginAttempt = (props) => <li {...props}>{props.children}</li>;

const LoginAttemptList = (props) => {
	const [loginAttempts, setLoginAttempts] = useState([]);
	const [filterValue, setFilterValue] = useState("");

	const handleFilterChange = (event) => {
		setFilterValue(event.target.value);
	};

	const filteredLoginAttempts = loginAttempts.filter((attempt) =>
		attempt.toLowerCase().includes(filterValue.toLowerCase())
	);

	const handleLoginAttempt = (attempt) => {
		setLoginAttempts((prevAttempts) => [...prevAttempts, attempt]);
	};

	return (
		<div className="Attempt-List-Main">
			<p>Recent activity</p>
			<input
				type="input"
				placeholder="Filter..."
				value={filterValue}
				onChange={handleFilterChange}
			/>
			<ul className="Attempt-List">
				{filteredLoginAttempts.map((attempt, index) => (
					<LoginAttempt key={index}>{attempt}</LoginAttempt>
				))}
			</ul>
			<button onClick={() => handleLoginAttempt("User logged in")}>
				Log in
			</button>
			<button onClick={() => handleLoginAttempt("User logged out")}>
				Log out
			</button>
		</div>
	);
};

export default LoginAttemptList;