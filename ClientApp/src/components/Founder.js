import React, { useState, useEffect } from 'react'

function Founder() {
	const [isLoading, setIsLoading] = useState(true)
	const [name, setName] = useState('')

	const getFounder = async () => {
		const response = await fetch('founder')
		const data = await response.json()
		console.log(data)
		setName(data.name)
		setIsLoading(false)
	}

	useEffect(() => {
		getFounder()
	}, [])

	return (
		<div>
			<p>{isLoading ? 'Loading...' : name}</p>
		</div>
	)
}

export default Founder
