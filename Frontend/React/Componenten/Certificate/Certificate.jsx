import React from 'react';
import PdfViewer from '../Utilities/PDFViewer';

export default function Certificate({ cert }) {
    return (
        <div className="bg-gray-700 rounded-lg p-4 shadow-md">
            <h5 className="text-lg font-bold">{cert.title}</h5>
            <p className="text-sm text-gray-300">{cert.description}</p>
            <p className="text-xs text-gray-400">
                {new Date(cert.issueDate).toLocaleDateString('nl-NL', { month: 'long', year: 'numeric' })}
            </p>
            <PdfViewer url={cert.pdfUrl} />
        </div>
    );
}
