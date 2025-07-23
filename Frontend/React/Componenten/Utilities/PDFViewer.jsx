import React, { useState } from 'react';
import { Document, Page, pdfjs } from 'react-pdf';
//import 'react-pdf/dist/esm/Page/AnnotationLayer.css';

// Configureer de PDF.js worker
pdfjs.GlobalWorkerOptions.workerSrc = `https://cdnjs.cloudflare.com/ajax/libs/pdf.js/${pdfjs.version}/pdf.worker.min.js`;

const PdfViewer = ({ url }) => {
    const [numPages, setNumPages] = useState(null);

    const onDocumentLoadSuccess = ({ numPages }) => {
        setNumPages(numPages);
    };

    return (
        <div>
            <Document
                file={url}
                onLoadSuccess={onDocumentLoadSuccess}
            >
                {/* Altijd alleen pagina 1 tonen */}
                <Page pageNumber={1} />
            </Document>
        </div>
    );
};

export default PdfViewer;