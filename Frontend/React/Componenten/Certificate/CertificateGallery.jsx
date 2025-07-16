import React, { useState, useEffect } from 'react';
import Certificate from './Certificate.jsx';

export default function CertificateGallery() {
    const [certificates, setCertificates] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        fetch('/api/certificate')
            .then(res => {
                if (!res.ok) throw new Error('Netwerkfout');
                return res.json();
            })
            .then(data => {
                setCertificates(data);
                setLoading(false);
            })
            .catch(err => {
                console.error(err);
                setError(err);
                setLoading(false);
            });
    }, []);

    if (loading) return <p>Bezig met laden…</p>;
    if (error) return <p>Fout bij laden: {error.message}</p>;

    return (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
            {certificates.map(cert => (
                <Certificate key={cert.id} cert={cert} />
            ))}
        </div>
    );
}